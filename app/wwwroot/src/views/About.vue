<template>
  <v-app>
    <div class="about">
      <v-col class="mb-4">
        <v-combobox
          v-model="select"
          :items="items"
          item-text="Name"
          label="選択してください"
          return-object
          outlined
          dense
        ></v-combobox>
        <v-btn small v-on:click="setSelect" data-bt="selectapi2">SelectAPI実行</v-btn>
      </v-col>
    </div>
  </v-app>
</template>

<script>
  export default {
    data: () => ({
      select: '',
      items: [],
      input_image: null,
      uploadImageUrl: ''
    }),
    mounted() {
      this.init()
    },
    methods: {
      async init() {
        await this.axios.get('http://localhost:5000/api/Food/')
            .then((response) => {
              this.items = response.data
              this.select = this.items.find((x) => x.FoodId === 5);
            })
            .catch((e) => {
              console.log(e)
            })
      },
      setSelect() {
        // console.log(this.$store.state.count)
        // this.$store.dispatch('increment')
        // console.log(this.$store.getters.doneTodos)
      }
    }
  }
</script>