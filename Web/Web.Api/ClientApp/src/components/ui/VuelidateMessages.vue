<template>
  <!-- <InlineMessage v-for="error of v$[propName].$errors" :key="error.$uid" severity="info" class="w-full">
    {{ error.$message }}
  </InlineMessage> -->

  <Message v-for="error of v[propName].$errors" severity="error" :key="error.$uid">
    {{error.$message}}
  </Message>
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
