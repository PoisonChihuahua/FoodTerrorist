import { createLocalVue, mount } from "@vue/test-utils"
import Component from "@/views/About.vue"
import Vuetify from "vuetify"
import VueRouter from "vue-router"
import flushPromises from "flush-promises"
import axios from "axios"
jest.mock('axios')

const resp = {
  data: [
    {
      FoodId: 1,
      Name: "米",
    },
    {
      FoodId: 2,
      Name: "パン",
    }
  ],
};
axios.get.mockResolvedValue(resp);

describe("Testing App component", () => {
  const localVue = createLocalVue()
  localVue.use(VueRouter)
  const router = new VueRouter()
  let vuetify
  let wrapper
  
  beforeEach(() => {
    vuetify = new Vuetify()
    wrapper = mount(Component, {
      localVue,
      vuetify,
      router,
      mocks: { axios },
    });
  });

  it("is a Vue instance", () => {
    expect(wrapper.isVueInstance).toBeTruthy()
  });

  it("コンボボックス内容確認", async () => {
    await flushPromises()
    expect(wrapper.vm.items[0].FoodId).toBe(1)
    expect(wrapper.vm.items[0].Name).toBe("米")
    expect(wrapper.vm.items[1].FoodId).toBe(2);
    expect(wrapper.vm.items[1].Name).toBe("パン");
  });

  it("ボタン押下", () => {
    const button = wrapper.find('[data-bt="selectapi2"]');
    button.trigger("click");
    expect(wrapper.isVueInstance).toBeTruthy();
  });

  it("コンボボックス取得例外", async () => {
    axios.get.mockRejectedValue(new Error("Async error"));
    wrapper = mount(Component, {
      localVue,
      vuetify,
      router,
      mocks: { axios },
    });
    await flushPromises();
    //expect(axios.get).toThrow("Async error");
    expect(wrapper.isVueInstance).toBeTruthy();
  });
});