<template>
   <nav class="services-static-menu">
      <slot />
   </nav>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class ServicesStaticMenuComponent extends Vue {

}
</script>

<style scoped>

.services-static-menu {
   margin-bottom: 30px;
   position: relative;
   width: 100%;
   background: #121B23;
}

.static-menu {
   margin: 0 auto;
   padding: 0 15px;
   max-width: 1320px;
   width: 100%;
   display: flex;
   align-items: center;
   justify-content: space-between;
}

.static-menu li {
   flex: 0 1 100%;
   max-width: 100%;
   transition: all 0.3s ease-out;
}

.static-menu li a {
   padding: 15px 10px;
   position: relative;
   font-size: 16px;
   font-weight: 600;
   line-height: 120%;
   color: #fff;
   display: flex;
   align-items: center;
   justify-content: center;
   text-align: center;
   transition: all 0.2s ease-out;
}

.static-menu li a::after {
   content: '';
   position: absolute;
   bottom: 0;
   left: 50%;
   transform: translateX(-50%);
   width: 0;
   height: 3px;
   background: #12be83;
   border-radius: 28px;
   transition: all 0.2s ease-out;
}

.static-menu li a:hover,
.static-menu li.active a {
   color: #12be83;
}

.static-menu li a:hover::after,
.static-menu li.active a::after {
   width: 100%;
}


@media all and (max-width: 970px) {
   .static-menu li a { padding: 15px 5px; font-size: 14px; }
}

@media all and (max-width: 840px) {
   .services-static-menu { display: none; }
}
</style>