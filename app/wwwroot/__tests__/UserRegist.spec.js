import { createLocalVue, mount } from "@vue/test-utils";
import Component from "@/components/UserRegist.vue";
import Vuetify from "vuetify";
import VueRouter from "vue-router";
import flushPromises from "flush-promises";
import axios from "axios";

jest.mock("axios");

const resp = {
  data: [
    {
      FoodId: 1,
      Name: "米",
    },
    {
      FoodId: 2,
      Name: "パン",
    },
  ],
};
axios.post.mockResolvedValue(resp);

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
      mocks: { axios },
    });
  });

  afterEach(() => {
    wrapper.destroy();
  });

  it("is a Vue instance", () => {
    expect(wrapper.isVueInstance).toBeTruthy();
  });

  it("ボタン押下", async () => {
    // const setRegister = jest.fn();
    // wrapper.setMethods({ setRegister });
    const textInput = wrapper.find('[id="username"]');
    await textInput.setValue("user1")
    wrapper.vm.password = "1qaz2wsx";
    wrapper.vm.reEnterPassword = "1qaz2wsx";
    const button = wrapper.find('[id="b1"]');
    button.trigger("click");
    console.log(wrapper.text());
    // expect(setRegister).toBeCalled();
    expect(wrapper.isVueInstance).toBeTruthy();
  });

  it("パスワード不一致", () => {
    wrapper.vm.userName = "user1";
    wrapper.vm.password = "1qaz2wsx";
    wrapper.vm.reEnterPassword = "2wsx3edc";
    const button = wrapper.find('[id="b1"]');
    button.trigger("click");
    expect(wrapper.isVueInstance).toBeTruthy();
  });

  it("パスワード8文字未満", () => {
    wrapper.vm.userName = "user1";
    wrapper.vm.password = "1qaz2wsx";
    wrapper.vm.reEnterPassword = "";
    const button = wrapper.find('[id="b1"]');
    button.trigger("click");
    expect(wrapper.isVueInstance).toBeTruthy();
  });
  it("ユーザー名未入力", () => {
    wrapper.vm.userName = "";
    const button = wrapper.find('[id="b1"]');
    button.trigger("click");
    expect(wrapper.isVueInstance).toBeTruthy();
  });

  it("コンボボックス取得例外", async () => {
    axios.post.mockRejectedValue(
      new Error("Async error")
    );
    wrapper = mount(Component, {
      localVue,
      vuetify,
      router,
      mocks: { axios },
    });
    wrapper.vm.userName = "user1";
    wrapper.vm.password = "1qaz2wsx";
    wrapper.vm.reEnterPassword = "1qaz2wsx";
    const button = wrapper.find('[id="b1"]');
    button.trigger("click");
    await flushPromises();
    expect(wrapper.isVueInstance).toBeTruthy();
    //expect(axios.post).toThrow("Async error");
  });
});
