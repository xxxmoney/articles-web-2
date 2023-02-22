<template>
  <!-- <InlineMessage v-for="error of v$[propName].$errors" :key="error.$uid" severity="info" class="w-full">
    {{ error.$message }}
  </InlineMessage> -->

  <span v-for="error of v[propName].$errors" :key="error.$uid" class="text-red-500 text-sm italic">
    {{ error.$message }}
  </span>
</template>

<script>
export default {
  props: {
    v: {
      type: Object,
      required: true
    },
    propName: {
      type: String,
      required: true
    }
  }
}
</script>
