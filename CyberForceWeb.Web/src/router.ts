import Vue from "vue";
import Router from "vue-router";
import { CAdminTablePage, CAdminEditorPage } from "coalesce-vue-vuetify/lib";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      name: "home",
      component: () => import("./views/Home.vue"),
    },
    {
      path: "/Contact",
      name: "home",
      component: () => import("./views/Contact.vue"),
    },
    {
      path: "/Manufacturing",
      name: "home",
      component: () => import("./views/Manufacturing.vue"),
    },
    {
      path: "/SolarGeneration",
      name: "home",
      component: () => import("./views/SolarGeneration.vue"),
    },
    {
      path: "/Login",
      name: "home",
      component: () => import("./views/Login.vue"),
    },
    {
      path: "/Admin",
      name: "home",
      component: () => import("./views/Admin.vue"),
    },

    // Coalesce admin routes
    {
      path: "/admin/:type",
      name: "coalesce-admin-list",
      component: CAdminTablePage,
      props: (r) => ({
        type: r.params.type,
      }),
    },
    {
      path: "/admin/:type/edit/:id?",
      name: "coalesce-admin-item",
      component: CAdminEditorPage,
      props: (r) => ({
        type: r.params.type,
        id: r.params.id,
      }),
    },
  ],
});
