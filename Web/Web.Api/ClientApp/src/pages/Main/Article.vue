<template>    
    <div>
        <Loading :loaded="loaded" />
        <div class="flex flex-col gap-8" v-if="article">
            <div class="flex flex-row justify-center flex-1">    
                <h1 v-if="!canEdit">{{ article.title }}</h1>          
                <Inplace v-else :closable="true">
                    <template #display>
                        <h1>{{ article.title }}</h1>
                    </template>
                    <template #content>
                        <InputText v-model="article.title" autoFocus />
                    </template>
                </Inplace>
            </div>
            <div class="flex flex-col md:flex-row gap-6 px-4">
                <div>
                    <Image :src="article.pictureName" :withImagesPath="true" class="object-cover md:rounded-l-3xl md:w-52 xl:w-72 h-96" />
                    <div v-if="canUpload" class="flex flex-row justify-center mt-3">
                        <FileUpload
                          mode="basic"
                          accept="image/*"
                          :customUpload="true" 
                          @uploader="uploadPicture"
                          :auto="true"
                          :chooseLabel="$t('common.upload')"
                        />
                    </div>
                </div>
                <div class="flex flex-col flex-1 gap-7">
                    <div v-if="article.user">
                        <span class="inline mr-2">{{ $t('common.by') }}:</span>
                        <span class="inline text-xs cursor-pointer text-hover-highlight" @click="goToUserAsync">{{ article.user.name + ' ' + article.user.surname }}</span>
                    </div>
                    <TinyMCE
                        v-if="canEdit"
                        api-key="no-api-key"
                        v-model="article.content"
                        :init="{
                            height: 500,
                            menubar: false,
                            plugins: [
                            'advlist autolink lists link image charmap print preview anchor',
                            'searchreplace visualblocks code fullscreen',
                            'insertdatetime media table paste code help wordcount'
                            ],
                            toolbar:
                            'undo redo | formatselect | bold italic backcolor | \
                            alignleft aligncenter alignright alignjustify | \
                            bullist numlist outdent indent | removeformat | help',
                            skin: 'oxide-dark',
                            content_css: 'dark'
                        }"
                        />
                    <p v-else v-html="article.content" class="tracking-wide leading-7"></p>
                </div>
            </div>
            <div v-if="canEdit" class="flex flex-row justify-end gap-3 p-2">
                <Button :label="$t('common.save')" @click="upsertArticleAsync" />
                <Button v-if="article.id" class="p-button-danger" :label="$t('common.delete')" @click="deleteArticle" />
            </div>
        </div>
    </div>
</template>

<script>
import { onMounted, onUnmounted, computed } from 'vue';
import { useArticleStore } from '../../store/article';
import { useAuthStore } from '../../store/auth';
import { useRoute } from 'vue-router';
import { useRouter } from 'vue-router';
import Image from '../../components/ui/Image.vue';
import Loading from '../../components/ui/Loading.vue';
import { showError, showSuccess } from '../../helpers/ToastHelper';
import { useToast } from 'primevue/usetoast';
import { useI18n } from 'vue-i18n';
import { useConfirm } from "primevue/useconfirm";

export default {
    components: {
        Image,
        Loading
    },
    setup() {
        const articleStore = useArticleStore();
        const authStore = useAuthStore();
        const route = useRoute();
        const router = useRouter();
        const toast = useToast();
        const { t } = useI18n();
        const confirm = useConfirm();

        const loaded = computed(() => articleStore.loaded);
        const articleId = computed(() => route.params.id);
        const article = computed({
            get: () => articleStore.current,
            set: (value) => articleStore.current = value
        });
        const upsertArticleAsync = async () => {
            try {
                await articleStore.upsertArticleAsync();
                showSuccess(toast, t);

                // Redirect to articles.
                await router.push("/articles");
            } catch (error) {
                console.log(error);
                showError(toast, t);
            }
        };
        const deleteArticle = () => {            
            // Show confirmation dialog to confirm before deleting.
            confirm.require({
                header: t('common.confirmation'),
                message: t('common.delete_confirmation'),
                icon: 'pi pi-exclamation-triangle',
                accept: async () => {
                    try {                
                        await articleStore.deleteArticleAsync();

                        // Redirect to articles page.
                        await router.push("/articles");
                    } catch (error) {
                        console.log(error);
                        showError(toast, t);
                    }
                }
            });
        };

        const uploadPicture = async (event) => {
            const reader = new FileReader();
            reader.readAsDataURL(event.files[0]);
            reader.onloadend = async () => {
                // Remove first part.
                const base64Data = reader.result.replace(/^data:image\/.*?;base64,/, '');

                try {
                    await articleStore.uploadPictureAsync(base64Data);
                    showSuccess(toast, t);
                }
                catch (error) {
                    console.error(error);
                    showError(toast, t);
                }
            };
        };

        onMounted(async () => {
            // Get article by id from params if present.
            if (articleId.value) {
                await articleStore.getArticleAsync(articleId.value);         
                return;                   
            }

            // Set current article to new article.
            articleStore.loaded = true;
            article.value = {
                title: 'Title'
            };
        });
        onUnmounted(() => {
            // Clear current article from store.
            articleStore.current = null;
        });

        const goToUserAsync = async () => {
            await router.push("/profile/" + article.value.user?.id);
        };

        const canEdit = computed(() => {
            if (article.value?.id) {
                return article.value.user?.id == authStore.user?.id;
            }
            return true;
        });
        const canUpload = computed(() => {
            return article.value?.id && canEdit.value;
        });

        return {
            loaded,
            article,
            canEdit,
            canUpload,
            goToUserAsync,
            upsertArticleAsync,
            deleteArticle,
            uploadPicture
        };
    },
    components: { Image, Loading }
}
</script>

<style scoped>
    :deep(.p-inplace-display) {
        padding: 0 !important;
        border-radius: 0 !important;
        transition: none !important;
    }
</style>
