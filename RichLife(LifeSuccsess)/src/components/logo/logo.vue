<template>
   <router-link to="/" class="logo" :class="[headerLogo ? 'header-logo' : '', $route.name == 'home' || $route.name == '' ? 'absolute' : '' ]">
      WellbeLife
   </router-link>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"

@Component
export default class LogoComponent extends Vue {

   @Prop({ type: String, default: '#121B23' }) color: string
   @Prop({ type: Boolean, default: false }) headerLogo: boolean

   setStyle(): Object {
      return {
         color: this.color
      }
   }

}
</script>

<style scoped>

.logo {
   font-size: 45px;
   font-family: 'Fineday', cursive;
   font-weight: 500;
   color: #121B23;
   /* text-transform: uppercase; */
}

.header-fixed .logo,
footer .logo {
   color: #fff;
}

header .logo,
header.whtieHeader .logo,
header.scroll .logo {
   color: #121B23;
}

@media all and (max-width: 530px) {
   header .logo { font-size: 40px; }
}

@media all and (max-width: 460px) {
   header .logo { font-size: 35px; }
}

@media all and (max-width: 350px) {
   header .logo { font-size: 27px; }
}
</style>