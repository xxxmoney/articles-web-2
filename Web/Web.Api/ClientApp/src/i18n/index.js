import { createI18n } from 'vue-i18n'
import { messages } from '../locales';

const i18n = createI18n({
    locale: 'en',
    messages,
    legacy: false
});

export default i18n;
  