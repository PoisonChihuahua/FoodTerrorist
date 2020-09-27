<template>
  <v-app id="app">
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
        <v-btn small v-on:click="setSelect">SelectAPI実行</v-btn>
        <img v-if="uploadImageUrl" :src="uploadImageUrl" />
        <v-file-input
          v-model="input_image"
          accept="image/*"
          label="File input"
          show-size
          prepend-icon="mdi-image"
          @change="onImagePicked"
        ></v-file-input>
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
      this.axios.get('http://localhost:5000/api/Food/')
          .then((response) => {
            this.items = response.data
            this.select = this.items.find((x) => x.FoodId === 5);
          })
          .catch((e) => {
            alert(e)
          })
    },
    methods: {
      setSelect() {
        console.log(this.$store.state.count)
        this.$store.dispatch('increment')
        console.log(this.$store.getters.doneTodos)
      },
      onImagePicked(file) {
        if (file !== undefined && file !== null) {
          if (file.name.lastIndexOf('.') <= 0) {
            return
          }
          const fr = new FileReader()
          fr.readAsDataURL(file)
          fr.addEventListener('load', () => {
            this.uploadImageUrl = fr.result
          })
        } else {
          this.uploadImageUrl = ''
        }
      }
    }
  }
</script>