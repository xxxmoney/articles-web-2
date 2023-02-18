import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from 'primevue/config';
// Styles import.
import './index.css'
import 'primevue/resources/themes/saga-blue/theme.css' // theme
import 'primevue/resources/primevue.min.css' // core css
import 'primeicons/primeicons.css' // icons

const app = createApp(App);

// Use PrimeVue.
app.use(PrimeVue);

app.mount('#app');
