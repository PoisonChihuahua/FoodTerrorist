<template>
  <v-app>
    <v-app-bar
      app
      clipped-left
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>This is the header.</v-toolbar-title>
      <v-spacer />
    </v-app-bar>
    <v-navigation-drawer
      v-model="drawer"
      app
      clipped
    >
      <v-list
        nav
      >
        <v-list-item v-for="menu in menus" :key="menu.title" :to="menu.url">
          <v-list-item-icon>
            <v-icon>{{ menu.icon }}</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>{{ menu.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-main>
      <router-view/>
    </v-main>
    <v-footer
      app
      inset
    >
    <p>{{ $t("message.hello") }}</p>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data () {
    return {
        drawer: false,
        menus: [
          { title: 'Home', icon: 'mdi-home', url: '/' },
          { title: 'About', icon: 'mdi-information-variant', url: '/about' }
        ]
    }
  }
}
</script>

<style>
</style>
