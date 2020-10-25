import { createLocalVue, mount } from "@vue/test-utils"
import Component from "@/App.vue"
import Vuetify from "vuetify"
import VueRouter from "vue-router";
import VueI18n from "vue-i18n";

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
  locale: "en", // set locale
  messages, // set locale messages
});

describe("Testing App component", () => {
  const localVue = createLocalVue()
  localVue.use(VueRouter);
  const router = new VueRouter();
  let vuetify;
  let wrapper;

  beforeEach(() => {
    vuetify = new Vuetify();
    wrapper = mount(Component, {
      localVue,
      vuetify,
      router,
      i18n
    }); 
  });
  
  it("is a Vue instance", () => {
    expect(wrapper.isVueInstance).toBeTruthy()
  })

  it("多言語確認", () => {
    expect(wrapper.html()).toContain("hello world");
  });

  it("多言語確認2", () => {
    i18n.locale = "ja";
    wrapper = mount(Component, {
      localVue,
      vuetify,
      router,
      i18n,
    }); 
    expect(wrapper.html()).toContain("こんにちは、世界");
  });
})
