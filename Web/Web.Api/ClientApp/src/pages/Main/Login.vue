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

    <Button @click.prevent="submit" :label="$t('main.pages.login.submit')" />
  </div>
</template>

<script>
  import { ref } from 'vue'
  import { useAuthStore } from '../../store/auth.js'

  export default {
    setup() {
      const authStore = useAuthStore();
      const model = ref({});

      const submit = () => {
        try {
          authStore.login(model.value.email, model.value.password);
        } catch (error) {
          console.error(error);
        }
      };

      return {
        model,
        submit
      }
    }
  }
</script>
