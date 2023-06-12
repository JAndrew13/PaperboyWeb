import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import 'vuetify/dist/vuetify.css'
import { createVuetify } from 'vuetify'
import Axios from 'axios'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
    Axios.defaults.baseURL = 'https://localhost:7053/'
} 
// else {
//     Axios.defaults.baseURL = 'https://wordle2023.azurewebsites.net/'
//   }

const vuetify = createVuetify({
    components,
    directives,
    theme: { defaultTheme: 'dark' },
        },
  )
const app = createApp(App)
app.use(router)
app.use(store)
app.use(vuetify)
app.mount('#app')




