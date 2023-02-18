import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from 'primevue/config';
import installI18n from './i18n';
import router from './router';

// Styles import.
import './index.css'
import 'primevue/resources/themes/saga-blue/theme.css' // theme
import 'primevue/resources/primevue.min.css' // core css
import 'primeicons/primeicons.css' // icons

const app = createApp(App);

// Use PrimeVue.
app.use(PrimeVue);

// Use i18n.
installI18n(app);

// Use router.
app.use(router);

app.mount('#app');
