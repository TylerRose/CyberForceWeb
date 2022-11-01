<template>
  <v-container>
    <v-card flat color="grey lighten-5">
      <c-loader-status
        v-slot
        :loaders="{
          'no-secondary-progress no-initial-content no-error-content': [
            loginService.isLoggedIn,
          ],
        }"
      >
        <v-card class="mb-4">
          <v-card-title>
            Welcome {{ userName }}, you are currently signed in.
          </v-card-title>
        </v-card>
      </c-loader-status>
      <v-row>
        <v-col cols="6">
          <v-card>
            <v-card-title> Login</v-card-title>
            <v-card-text>
              <v-text-field
                v-model="email"
                label="Email"
                required
                autofocus
              />
              <v-text-field
                v-model="password"
                label="Password"
                type="password"
                required
              />
            </v-card-text>
            <v-card-actions>
              <v-spacer/>
              <v-btn
                color="primary"
                :disabled="!isLoggedIn"
                @click="logout"
              >
                Logout
              </v-btn>
              <v-btn
                color="primary"
                type="submit"
                :disabled="(!email || !password) && isLoggedIn"
                @click="login"
              >
                Login
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import {LoginServiceViewModel} from "@/viewmodels.g";

@Component({})
export default class Login extends Vue {
  loginService = new LoginServiceViewModel();
  isLoggedIn = false;
  tab = 0;
  name = "";
  email = "";
  password = "";
  password2 = "";
  signInType = "cookie";
  userName = "";

  async created() {
    await this.loginService.isLoggedIn();
    await this.loginService.getUserInfo();
    this.isLoggedIn = this.$isLoggedIn;
    this.userName = this.loginService.getUserInfo.result?.name ?? "";
  }

  async login() {
    await this.logout(false);
    if (this.signInType === "jwt") {
      await this.loginService.getToken(this.email, this.password);
      if (this.loginService.getToken.wasSuccessful) {
        localStorage.setItem(
          "token",
          (this.loginService.getToken.result as any).token
        );
      }
    } else {
      await this.loginService.login(this.email, this.password);
    }
    window.location.reload();
  }

  async register() {
    await this.loginService.createAccount(this.name, this.email, this.password);
    window.location.reload();
  }

  async logout(reload = true) {
    await this.loginService.logout();
    localStorage.removeItem("token");
    if (reload) {
      window.location.reload();
    }
  }
}
</script>