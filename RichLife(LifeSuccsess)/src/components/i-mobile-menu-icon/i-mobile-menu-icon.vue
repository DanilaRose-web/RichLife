<template>
   <div class="i-mobile-menu-icon" @click="$emit('onClick')">
      <div class="item"><span></span></div>
      <div class="item"><span></span></div>
      <div class="item"><span></span></div>
   </div>
</template>

<script lang="ts">

import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class IMobileMenuIconComponent extends Vue {

}
</script>

<style>

.i-mobile-menu-icon {
   margin-right: 20px;
   width: 35px;
   height: 21px;
   display: flex;
   flex-direction: column;
   align-items: flex-start;
   justify-content: space-between;
   cursor: pointer;
}

.i-mobile-menu-icon.allWidth {
   display: flex;
}
 
.header-fixed .i-mobile-menu-icon .item span {
   background: #fff;
}


.i-mobile-menu-icon .item {
   max-width: 100%;
   width: 100%;
   height: 3px;
   position: relative;
   display: flex;
   justify-content: flex-start;
   transition: all 0.2s ease-out;
}

.i-mobile-menu-icon .item span {
   border-radius: 5px;
   width: 100%;
   height: 3px;
   background: #121B23;
   display: flex;
   transition: all 0.2s ease-out;
}

.i-mobile-menu-icon .item::after {
   content: '';
   position: absolute;
   top: 0;
   right: -2px;
   width: 3px;
   height: 3px;
   border-radius: 50%;
   background: #12be83;
   opacity: 0;
   visibility: hidden;
   z-index: 1;
   transition: all 0.2s ease-out;
}

.i-mobile-menu-icon:hover .item span {
   width: 80%;
}

.i-mobile-menu-icon:hover .item::after {
   opacity: 1;
   visibility: visible;
   right: 0;
}

header.whtieHeader .i-mobile-menu-icon .item span,
header.static .i-mobile-menu-icon .item span,
header.scroll .i-mobile-menu-icon .item span {
   background: #121B23;
}

@media all and (max-width: 350px) {
   .i-mobile-menu-icon { margin-right: 10px; }
}



</style>