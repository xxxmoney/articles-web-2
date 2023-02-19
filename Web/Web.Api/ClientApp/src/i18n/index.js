import { createI18n } from 'vue-i18n'
import { messages } from '../locales';

const i18n = createI18n({
    locale: 'en',
    messages,
    legacy: false
});

/** Installs i18n to Vue app. */
export default function installI18n(app) {
    app.config.globalProperties.$t = i18n.global.t;
    app.use(i18n);
}
  