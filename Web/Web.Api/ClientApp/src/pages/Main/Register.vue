<template>
  <div class="m-auto max-w-xs form">
    <div class="form-part">
      <label for="">{{ $t('common.email') }}</label>
      <InputText type="text" v-model="model.email" />
    </div>

    <div class="form-part">
      <label for="">{{ $t('common.name') }}</label>
      <InputText type="text" v-model="model.name" />
    </div>

    <div class="form-part">
      <label for="">{{ $t('common.surname') }}</label>
      <InputText type="text" v-model="model.surname" />
    </div>

    <div class="form-part">
      <label for="">{{ $t('common.password') }}</label>
      <InputText type="text" v-model="model.password" />
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

  export default {
    setup() {
      const authStore = useAuthStore();
      const model = ref({});
      const passwordConfirmation = ref();


      return {
        model,
        passwordConfirmation
      }
    }
  }
</script>
