<template>
  <div class="home">
    <UserRegist/>
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
