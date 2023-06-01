// main.ts
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { createVuetify } from 'vuetify'
import 'vuetify/dist/vuetify.css'

const app = createApp(App)

app.use(router)
app.use(createVuetify())
app.mount('#app')
