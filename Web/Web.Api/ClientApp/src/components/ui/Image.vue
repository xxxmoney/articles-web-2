<template>
    <img :src="srcComputed" class="" />
</template>

<script>
import { computed } from 'vue';

export default {
    props: {
        src: {
            type: String,
            required: true
        },
        withImagesPath: {
            type: Boolean,
            default: false
        }
    },
    setup(props) {
        const srcComputed = computed(() => {
            // Return default if empty.
            if(!props.src) {
                return '/src/assets/default_thumb.jpg';
            }

            // Return with pages if withImagesPath is true.
            if (props.withImagesPath) {
                return `/images/${props.src}`;
            }

            // Return src as is.
            return props.src;
        });

        return {
            srcComputed
        };
    }
}
</script>
