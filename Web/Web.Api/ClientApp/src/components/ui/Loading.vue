<template>
    <teleport to="body">
		<div class="absolute z-50 left-0 top-0 w-screen h-screen flex flex-row justify-center items-center bg-gray-500 opacity-70" v-if="!loaded">
			<div class="items-center animate-spin">
                <i class="pi pi-spin pi-spinner text-5xl"></i>
			</div>
		</div>
	</teleport>
</template>

<script>
export default {
    props: {
        loaded: {
            type: Boolean,
            default: true
        }
    },
    setup () {
        

        return {}
    }
}
</script>
