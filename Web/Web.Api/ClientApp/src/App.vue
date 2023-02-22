<template>
    <Toast teleport="body" />
    <ConfirmDialog />

    <router-view />
</template>

<script>
  import Toast from 'primevue/toast';
  import ConfirmDialog from 'primevue/confirmdialog';
  import { useI18n } from 'vue-i18n';
  import { getLocale } from './helpers/LocaleHelper';

  export default {
    components: {
      Toast,
      ConfirmDialog
    },
    setup() {
      const i18n = useI18n();

      // Initialize locale from local storage.
      i18n.locale.value = getLocale();

      return {};
    }
  }
</script>
