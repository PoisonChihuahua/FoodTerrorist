import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import store from './store'
import axios from 'axios'
import VueAxios from "vue-axios"
import router from './router'
import VueI18n from "vue-i18n"

Vue.config.productionTip = false

Vue.use(VueAxios, axios);

const messages = {
  en: {
    message: {
      hello: "hello world",
    },
  },
  ja: {
    message: {
      hello: "こんにちは、世界",
    },
  },
};

// Create VueI18n instance with options
const i18n = new VueI18n({
  locale: "ja", // set locale
  messages, // set locale messages
});

new Vue({
  vuetify,
  store,
  router,
  i18n,
  render: (h) => h(App)
}).$mount("#app");
