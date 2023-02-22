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
      <InputText type="password" v-model="model.password" />
      <VuelidateMessages :v="v$" propName="password" />
    </div>

    <div class="form-part">
      <label for="">{{ $t('main.pages.register.password_confirmation') }}</label>
      <InputText type="password" v-model="model.passwordConfirmation" />
      <VuelidateMessages :v="v$" propName="passwordConfirmation" />
    </div>

    <div></div>

    <Button @click="submitAsync" :label="$t('main.pages.register.submit')" />
  </div>
</template>

<script>
  import { ref } from 'vue'
  import { useAuthStore } from '../../store/auth.js'
  import { useI18n } from 'vue-i18n';
  import { showSuccess, showError } from '../../helpers/ToastHelper.js'
  import { useToast } from "primevue/usetoast"
  import { useRouter } from 'vue-router'
  import { useVuelidate } from '@vuelidate/core'
  import { required, email, createIsEqual } from '../../vuelidate';
  import VuelidateMessages from '../../components/ui/VuelidateMessages.vue';

  export default {
    components: {
      VuelidateMessages
    },
    setup() {
      const authStore = useAuthStore();
      const { t } = useI18n();
      const toast = useToast();
      const router = useRouter();

      const model = ref({});
      const equal = createIsEqual(() => model.value.password);
      const rules = {
          name: {
              required
          },
          surname: {
              required
          },
          email: {
              required, email
          },
          password: {
              required
          },
          passwordConfirmation: {
              required, equal
          },
      }
      const v$ = useVuelidate(rules, model);

      const submitAsync = async () => {
        try {
          // Validate model.
          const isValid = await v$.value.$validate();
          if (!isValid) {
            return;
          }

          // Register with values from model.
          await authStore.registerAsync(model.value.name, model.value.surname, model.value.email, model.value.password);

          showSuccess(toast, t);

          // Navigate to login page.
          router.push({ name: 'login' });
        } catch (error) {
          console.error(error);
          showError(toast, t, error);
        }
      };

      return {
        model,
        v$,
        submitAsync
      }
    }
  }
</script>
