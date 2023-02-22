<template>
    <img :src="src ?? '/src/assets/default_thumb.jpg'" class="" />
</template>

<script>
export default {
    props: {
        src: {
            type: String,
            required: true
        }
    },
}
</script>
