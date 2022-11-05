<template>
  <v-app id="vue-app">
    <v-app-bar app color="primary" dark dense clipped-left height="100px">
      <router-link to="/">
        <v-sheet width="300" color="grey">
          <v-img :src="require('@/assets/sole-zonsolisenergy.png')" />
        </v-sheet>
      </router-link>

      <v-toolbar-title class="px-4">
        <router-link
          to="/contact"
          style="text-decoration: none"
          class="white--text"
        >
          <v-btn class="pa-8" outlined> Contact Us</v-btn>
        </router-link>
      </v-toolbar-title>

      <v-toolbar-title class="px-4">
        <router-link
          to="/Manufacturing"
          style="text-decoration: none"
          class="white--text"
        >
          <v-btn class="pa-8" outlined> Manufacturing</v-btn>
        </router-link>
      </v-toolbar-title>

      <v-toolbar-title class="px-4">
        <router-link
          to="/SolarGeneration"
          style="text-decoration: none"
          class="white--text"
        >
          <v-btn class="pa-8" outlined> Solar Generation</v-btn>
        </router-link>
      </v-toolbar-title>

      <v-toolbar-title
        v-if="$userRoles && $userRoles.includes('SuperAdmin')"
        class="px-4"
      >
        <router-link
          to="/Admin"
          style="text-decoration: none"
          class="white--text"
        >
          <v-btn class="pa-8" outlined> Admin</v-btn>
        </router-link>
      </v-toolbar-title>
      <v-toolbar-title class="px-4">
        <router-link
          to="/Login"
          style="text-decoration: none"
          class="white--text"
        >
          <v-btn class="pa-8" outlined> Login</v-btn>
        </router-link>
      </v-toolbar-title>
    </v-app-bar>

    <v-main class="ma-8">
      <transition
        name="router-transition"
        mode="out-in"
        appear
        @enter="routerViewOnEnter"
      >
        <router-view ref="routerView" :key="$route.path" />
      </transition>
    </v-main>
    <v-footer height="100px" class="ma-3 pa-3">
      <v-row justify="center" align="center">
        <v-toolbar-title class="px-8">
          <v-sheet width="300" color="grey">
            <v-img :src="require('@/assets/vitavehiculum.png')" />
          </v-sheet>
        </v-toolbar-title>
        <v-toolbar-title class="px-8">
          <router-link to="/contact" style="text-decoration: none">
            <v-btn class="pa-8" outlined> Subscribe To Newsletter</v-btn>
          </router-link>
        </v-toolbar-title>
        <v-toolbar-title class="px-8">
          <v-card flat>
            <v-sheet class="pa-5" color="#F5F5F5">
              <v-row>
                <router-link to="/contact" style="text-decoration: none">
                  Contact Us
                </router-link>
              </v-row>
              <v-row>
                <router-link to="/Manufacturing" style="text-decoration: none">
                  Manufacturing
                </router-link>
              </v-row>
              <v-row>
                <router-link
                  to="/SolarGeneration"
                  style="text-decoration: none"
                >
                  Solar Generation
                </router-link>
              </v-row>
            </v-sheet>
          </v-card>
        </v-toolbar-title>
      </v-row>
    </v-footer>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

@Component({
  components: {},
})
export default class App extends Vue {
  drawer: boolean | null = null;
  routeComponent: Vue | null = null;

  get routeMeta() {
    if (!this.$route || this.$route.name === null) return null;

    return this.$route.meta;
  }

  routerViewOnEnter() {
    this.routeComponent = this.$refs.routerView as Vue;
  }

  created() {
    const baseTitle = document.title;
    this.$watch(
      () => (this.routeComponent as any)?.pageTitle,
      (n: string | null | undefined) => {
        if (n) {
          document.title = n + " - " + baseTitle;
        } else {
          document.title = baseTitle;
        }
      },
      { immediate: true }
    );
  }
}
</script>

<style lang="scss">
.router-transition-enter-active,
.router-transition-leave-active {
  // transition: 0.2s cubic-bezier(0.25, 0.8, 0.5, 1);
  transition: 0.1s ease-out;
}

.router-transition-move {
  transition: transform 0.4s;
}

.router-transition-enter,
.router-transition-leave-to {
  opacity: 0;
  // transform: translateY(5px);
}
</style>
