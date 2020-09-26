<template>
  <v-container>
    <v-row class="text-center">
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
      </v-col>

      <v-col
        class="mb-5"
        cols="12"
      >
        <h2 class="headline font-weight-bold mb-3">
          ユーザ登録
        </h2>
        <v-text-field
            v-model="userName"
            label="ユーザ名"
        ></v-text-field>
        <v-text-field
            v-model="password"
            label="*パスワード"
            :append-icon="passwordShow ? 'mdi-eye' : 'mdi-eye-off'"
            :rules="[rules.required, rules.min]"
            :type="passwordShow ? 'text' : 'password'"
            hint="At least 8 characters"
            @click:append="passwordShow = !passwordShow"
        ></v-text-field>
        <v-text-field
            v-model="reEnterPassword"
            label="*パスワード(再入力)"
            :append-icon="reEnterPasswordShow ? 'mdi-eye' : 'mdi-eye-off'"
            :rules="[rules.required, rules.min]"
            :type="reEnterPasswordShow ? 'text' : 'password'"
            hint="At least 8 characters"
            @click:append="reEnterPasswordShow = !reEnterPasswordShow"
        ></v-text-field>
        <v-btn small v-on:click="setRegister">登録</v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
  export default {
    name: 'Combobox',

    data: () => ({
      userName: '',
      password: '',
      passwordShow: false,
      reEnterPassword: '',
      reEnterPasswordShow: false,
      rules: {
        required: value => !!value || 'Required.',
        min: v => v.length >= 8 || 'Min 8 characters',
      },
      select: [],
      items: [],
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
        //console.log(this.select)
        //console.log(this.userName)
        console.log(this.$store.state.count)
        //this.$store.commit('increment')
        this.$store.dispatch('increment')
        console.log(this.$store.getters.doneTodos)
      },
      setRegister() {
        console.log(this.userName)
        console.log(this.password)
        if(this.userName.length < 1)
        {
          console.log('ユーザー名を入力してください')
        }
        if(this.password.length < 8 || this.reEnterPassword.length < 8)
        {
          console.log('8文字以上入力してください')
          return
        }
        if(this.password === this.reEnterPassword)
        {
          console.log('パスワード一致')
          this.axios.post('http://localhost:5000/api/UserRegist/', {
            userName: this.userName,
            password: this.password
          })
          .then((response) => {
            alert('更新成功')
          })
          .catch((e) => {
            alert(e)
          })
        }
        else
        {
          console.log('パスワード不一致')
        }
      }
    }
  }
</script>
