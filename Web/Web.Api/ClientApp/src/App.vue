<template>
    <Toast teleport="body" />

    <router-view />
</template>

<script>
  import Toast from 'primevue/toast';

  export default {
    components: {
      Toast
    }
  }
</script>
