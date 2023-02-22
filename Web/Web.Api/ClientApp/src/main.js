import { createApp } from 'vue';
import App from './App.vue';
import PrimeVue from 'primevue/config';
import i18n from './i18n';
import router from './router';
import pinia from './store';
import ToastService from 'primevue/toastservice';
import Loading from './components/ui/Loading.vue';
import ConfirmationService from 'primevue/confirmationservice';

// Axios initialize.
import './axios'

// Styles import.
import './index.css'
import 'primevue/resources/themes/saga-blue/theme.css' // theme
import 'primevue/resources/primevue.min.css' // core css
import 'primeicons/primeicons.css' // icons

const app = createApp(App);

// Use PrimeVue.
app.use(PrimeVue);

// Use PrimeVue ToastService.
app.use(ToastService);

// Use Primevue ConfirmService.
app.use(ConfirmationService);

// Use i18n.
app.config.globalProperties.$t = i18n.global.t;
app.use(i18n);

// Use router.
app.use(router);

// Use pinia.
app.use(pinia);

app.mount('#app');
