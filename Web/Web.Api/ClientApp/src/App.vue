<template>
    <Toast teleport="body" />

    <router-view />
</template>

<script>
  import Toast from 'primevue/toast';
  import { useI18n } from 'vue-i18n';
  import { getLocale } from './helpers/LocaleHelper';

  export default {
    components: {
      Toast
    },
    setup() {
      const i18n = useI18n();

      // Initialize locale from local storage.
      i18n.locale.value = getLocale();

      return {};
    }
  }
</script>
