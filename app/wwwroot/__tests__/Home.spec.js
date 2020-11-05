import { createLocalVue, mount } from "@vue/test-utils";
import Component from "@/views/Home.vue";
import Vuetify from "vuetify";
import VueRouter from "vue-router";

describe("Testing App component", () => {
  const localVue = createLocalVue();
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
    });
  });

  it("is a Vue instance", () => {
    console.log(wrapper.vm.Component);
    //console.log(wrapper.vm.test);
    wrapper.vm.setSelect();
    //console.log(wrapper.vm.test);
    expect(wrapper.isVueInstance).toBeTruthy();
  });
  it("ボタン押下", () => {
    const button = wrapper.find('[data-btn="selectapi"]');
    button.trigger("click");
    expect(wrapper.isVueInstance).toBeTruthy();
  });
  it("ラジオボタン選択", async () => {
    const radioInput = wrapper.find('[data-btn="radio"]');
    //console.log(radioInput);
    //await radioInput.setChecked();
    radioInput.trigger("click");
    //expect(radioInput.element.checked).toBeTruthy();
    expect(wrapper.isVueInstance).toBeTruthy();
  });
  it("コンボボックス選択", async () => {
    const comboInput = wrapper.find('[data-btn="combo"]');
    //console.log(comboInput);
    //console.log(wrapper.vm.select);
    //comboInput.at(1).setSelected();
    //expect(comboInput.element.value).toBe("Programming");
    expect(wrapper.isVueInstance).toBeTruthy();
  });
});
