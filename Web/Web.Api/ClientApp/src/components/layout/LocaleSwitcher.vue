<template>
    <Dropdown v-model="selected" :options="languages" optionLabel="name" optionValue="code" class="" />
</template>

<script>
    import { computed, ref, watch } from 'vue';
    import { useI18n } from 'vue-i18n';
    import { locales } from '../../locales';
    import { getLocale, setLocale } from '../../helpers/LocaleHelper';

    export default {
        setup () {
            const i18n = useI18n();

            const selected = ref(getLocale());

            /** Changes locale in i18n and in locale storage. */
            const switchLocale = (locale) => {
                i18n.locale.value = locale;
                setLocale(locale);
            };

            // Watches selected to switch locale.
            watch(selected, (locale) => {
                switchLocale(locale);
            });

            const languages = computed(() => {
                return Object.keys(locales).map((code) => {
                    return {
                        code,
                        name: locales[code].name
                    }
                });
            });

            return {
                languages,
                selected
            }
        }
    }
</script>
