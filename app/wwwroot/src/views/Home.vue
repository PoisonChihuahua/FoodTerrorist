<template>
  <div class="home">
    <UserRegist msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
// @ is an alias to /src
import UserRegist from '@/components/UserRegist.vue'

export default {
  name: 'Home',
  components: {
    UserRegist
  }
}
</script>
