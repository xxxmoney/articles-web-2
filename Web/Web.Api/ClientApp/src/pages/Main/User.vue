<template>
    <div>
        <Loading :loaded="loaded" />

        <div v-if="user" class="card m-auto pt-8 w-96 bg-base-100 shadow-xl">
            <figure>
                <Image src="/src/assets/default_image_user.jpg" class="rounded-md" />
            </figure>
            <div class="card-body grid grid-cols-3">
                <span class="text-label">{{ $t('common.name') }}:</span>
                <span class="text-base-content col-span-2">{{ user.name }}</span>
                <span class="text-label">{{ $t('common.surname') }}:</span>
                <span class="text-base-content col-span-2">{{ user.surname }}</span>
                <span class="text-label">{{ $t('common.email') }}:</span>
                <a :href="'mailto:' + user.email" class="text-base-content col-span-2">{{ user.email }}</a>
            </div>
        </div>
    </div>
</template>

<script>
import { useUserStore } from '../../store/user';
import { useAuthStore } from '../../store/auth';
import { computed, onMounted } from 'vue';
import Loading from '../../components/ui/Loading.vue';
import { useRoute } from 'vue-router';
import { showError } from '../../helpers/ToastHelper';
import { useToast } from 'primevue/usetoast';
import { useI18n } from 'vue-i18n';
import { useRouter } from 'vue-router';
import Image from '../../components/ui/Image.vue';

export default {
    components: {
        Loading,
        Image
    },
    setup () {
        const userStore = useUserStore();
        const authStore = useAuthStore();
        const route = useRoute();
        const router = useRouter();
        const loaded = computed(() => userStore.loaded);
        const toast = useToast();
        const { t } = useI18n();

        const userId = computed(() => route.params.id ?? authStore.user?.id);
        const user = computed(() => userStore.current);

        onMounted(async () => {
            try {
                // Redirect if user id is not provided.
                if(!userId.value) {
                    await router.push("/");
                    return;
                }

                // Get user.
                await userStore.getUserAsync(userId.value);                
            } catch (error) {
                console.error(error);
                showError(toast, t);
            }
        });

        return {
            loaded,
            user
        }
    }
}
</script>

<style scoped>
    .text-label {
        
    }
</style>