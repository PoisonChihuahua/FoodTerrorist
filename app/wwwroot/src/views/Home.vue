<template>
  <div>
    <v-container>
      <v-row>
        <v-col><UserRegist/></v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-btn small v-on:click="setSelect" data-btn="selectapi" >SelectAPI実行</v-btn>
        </v-col>
        <v-col>
          <v-radio-group row >
            <v-radio label="はい"           value="radio-1" data-btn="radio" ></v-radio>
            <v-radio label="どちらでもない"  value="radio-2"></v-radio>
            <v-radio label="いいえ"         value="radio-3"></v-radio>
          </v-radio-group>
        </v-col>
      </v-row>
      <v-row>
        <v-combobox
          v-model="select"
          :items="items"
          label="Select a favorite activity or create a new one"
          multiple
          data-btn="combo"
        ></v-combobox>
      </v-row>
      <v-row>
        <v-col><Dialog/></v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
// @ is an alias to /src
import UserRegist from '@/components/UserRegist.vue'
import Dialog from '@/components/Dialog.vue'

export default {
  name: 'Home',
  components: {
    UserRegist,
    Dialog
  },
  data: () => ({
    select:[],
    items: [
      'Programming',
      'Design',
      'Vue',
      'Vuetify',
    ],
  }),
  methods: {
    setSelect() {
      //console.log(this.$store.state.count)
      //this.$store.dispatch('increment')
      //console.log(this.$store.getters.doneTodos)
    }
  }
}
</script>

<style lang="scss">
.home{
  width: 500px;
}
</style>
