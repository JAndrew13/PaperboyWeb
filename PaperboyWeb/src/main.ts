import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import 'vuetify/dist/vuetify.css'
import { createVuetify } from 'vuetify'
import Axios from 'axios'
import 'vuetify/styles'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

import '@mdi/font/css/materialdesignicons.css'
import { mdi } from 'vuetify/iconsets/mdi'

if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
    Axios.defaults.baseURL = 'https://localhost:7053/'
} 

const vuetify = createVuetify({
    components,
    directives,
   
    icons: {
        defaultSet: 'mdi',
        sets: {
          mdi
        }
      },
    theme: { 
      defaultTheme: 'light',
      themes: {
        light: {
          colors: {
            primary: '#20AF97', // lilac
            secondary: '#4E9DAD', // moonstone
            accent: '#F2EBBF', // vanilla
            purp:' #3B297Aff',
            blush: '#CA5E76ff',
            verdi:' #679E9Eff',
            aquamarine:' #28E7ABff',
          },
        },
      },
    },
  })
const app = createApp(App)
app.use(router)
app.use(store)
app.use(vuetify)
app.mount('#app')
