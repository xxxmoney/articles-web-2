<template>    
    <div class="flex flex-col gap-8" v-if="article">
        <Loading :loaded="loaded" />

        <h1 class="text-center flex-1">{{ article.title }}</h1>
        <div class="flex flex-col md:flex-row gap-6 px-4">
            <Image :src="article.image" class="object-cover md:rounded-l-3xl md:w-52 xl:w-72 max-h-96" />
            <div class="flex flex-col flex-1 gap-7">
                <div>
                    <span class="inline mr-2">{{ $t('common.by') }}:</span>
                    <span class="inline text-xs cursor-pointer text-hover-highlight" @click="goToUserAsync">{{ article.user.name + ' ' + article.user.surname }}</span>
                </div>
                <p v-html="article.content" class="tracking-wide leading-7"></p>
            </div>
        </div>
        <div v-if="canEdit" class="flex flex-row justify-end gap-3 p-2">
            <Button :label="$t('common.save')" @click="upsertArticleAsync" />
            <Button class="p-button-danger" :label="$t('common.delete')" @click="deleteArticle" />
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
        const article = computed(() => articleStore.current);
        const upsertArticleAsync = async () => {
            try {
                await articleStore.upsertArticleAsync();
                showSuccess(toast, t);
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
                    } catch (error) {
                        console.log(error);
                        showError(toast, t);
                    }
                }
            });
        };

        onMounted(async () => {
            // Get article by id from params.
            await articleStore.getArticleAsync(articleId.value);            
        });
        onUnmounted(() => {
            // Clear current article from store.
            articleStore.current = null;
        });

        const goToUserAsync = async () => {
            await router.push("/profile/" + article.value.user.id);
        };

        const canEdit = computed(() => {
            if (article.value) {
                return article.value.user.id == authStore.user?.id;
            }
            return false;
        });

        return {
            loaded,
            article,
            canEdit,
            goToUserAsync,
            upsertArticleAsync,
            deleteArticle
        };
    },
    components: { Image, Loading }
}
</script>
