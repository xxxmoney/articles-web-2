<template>
  <div class="m-auto max-w-xs form">
    <div class="form-part">
      <label for="">{{ $t('common.email') }}</label>
      <InputText type="text" v-model="model.email" />
    </div>

    <div class="form-part">
      <label for="">{{ $t('common.password') }}</label>
      <InputText type="password" v-model="model.password" />
    </div>

    <div></div>

    <Button @click="submitAsync" :label="$t('main.pages.login.submit')" />
  </div>
</template>

<script>
  import { ref } from 'vue'
  import { useAuthStore } from '../../store/auth.js'
  import { useVuelidate } from '@vuelidate/core'
  import { useI18n } from 'vue-i18n';
  import { showSuccess, showError } from '../../helpers/ToastHelper.js'
  import { useToast } from "primevue/usetoast";

  export default {
    setup() {
      const authStore = useAuthStore();
      const v = useVuelidate();
      const { t } = useI18n();
      const toast = useToast();
      
      const model = ref({});

      const submitAsync = async () => {
        try {
          // Login with values from model.
          await authStore.loginAsync(model.value.email, model.value.password);

          showSuccess(toast, t);

          // Navigate to home page.
          router.push({ name: 'home' });
        } catch (error) {
          console.error(error);
          showError(toast, t);
        }
      };

      return {
        model,
        submitAsync
      }
    }
  }
</script>
