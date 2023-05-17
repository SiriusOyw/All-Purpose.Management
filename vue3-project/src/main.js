import { createApp } from 'vue'
import App from './App.vue'
import router from './router/index'
import {createPinia} from 'pinia'  
import './style.css'
import 'element-plus/dist/index.css'

const pinia = createPinia();//实例化pinia

createApp(App).use(router).use(pinia).mount('#app')
