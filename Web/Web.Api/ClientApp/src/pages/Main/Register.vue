<template>
  <div class="m-auto max-w-xs form">
    <div class="form-part">
      <label for="">{{ $t('common.email') }}</label>
      <InputText type="text" v-model="model.email" />
      <VuelidateMessages :v="v$" propName="email" />
    </div>

    <div class="form-part">
      <label for="">{{ $t('common.name') }}</label>
      <InputText type="text" v-model="model.name" />
      <VuelidateMessages :v="v$" propName="name" />
    </div>

    <div class="form-part">
      <label for="">{{ $t('common.surname') }}</label>
      <InputText type="text" v-model="model.surname" />
      <VuelidateMessages :v="v$" propName="surname" />
    </div>

    <div class="form-part">
      <label for="">{{ $t('common.password') }}</label>
      <InputText type="text" v-model="model.password" />
      <VuelidateMessages :v="v$" propName="password" />
    </div>

    <div class="form-part">
      <label for="">{{ $t('main.pages.register.password_confirmation') }}</label>
      <InputText type="text" v-model="passwordConfirmation" />
    </div>

    <div></div>

    <Button :label="$t('main.pages.register.submit')" />
  </div>
</template>

<script>
  import { ref } from 'vue'
  import { useAuthStore } from '../../store/auth.js'
  import { useI18n } from 'vue-i18n';
  import { showSuccess, showError } from '../../helpers/ToastHelper.js'
  import { useToast } from "primevue/usetoast"
  import { useRouter } from 'vue-router'
  import VuelidateMessages from '../../components/ui/VuelidateMessages.vue';

  export default {
    components: {
      VuelidateMessages
    },
    setup() {
      const authStore = useAuthStore();
      const { t } = useI18n();
      const toast = useToast();
      const passwordConfirmation = ref();
      const router = useRouter();

      const model = ref({});

      const submitAsync = () => {
        try {
          // Register with values from model.
          authStore.registerAsync(model.value.name, model.value.surname, model.value.email, model.value.password);

          showSuccess(toast, t);

          // Navigate to login page.
          router.push({ name: 'login' });
        } catch (error) {
          console.error(error);
          showError(toast, t);
        }
      };

      return {
        model,
        passwordConfirmation,
        submitAsync
      }
    }
  }
</script>
