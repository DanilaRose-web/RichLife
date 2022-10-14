<template>
   <div>
      <div class="about-img" @click="showAboutModal = true">
         <img src="/assets/img/about/about-us.webp" alt="О Нас">
         <svg><use xlink:href="/assets/img/svg-sprite.svg#icon-play"></use></svg>
      </div>

      <i-modal :show="showAboutModal" @close="showAboutModal = false">
         <div class="about-video">
            <iframe height="400" src="https://www.youtube.com/embed/YBikTL5Zd50" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
         </div>
      </i-modal>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class AboutUsComponent extends Vue {

   showAboutModal: boolean = false
}
</script>

<style scoped>

.about-img {
   margin: 0 auto;
   max-width: 900px;
   width: 100%;
   position: relative;
   cursor: pointer;
}

.about-img::before,
.about-img::after {
   content: '';
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
   transition: all 0.3s ease-out;
}

.about-img::after {
   opacity: 0;
   visibility: hidden;
   border: 10px solid #12be83;
   transform: scale(1.03);
}

.about-img::before {
   background: rgba(0, 0, 0, 0.5);
}

.about-img img {
   max-width: 100%;
   height: auto;
}

.about-img svg {
   position: absolute;
   top: 50%;
   left: 50%;
   transform: translate(-50%, -50%);
   width: 60px;
   height: 60px;
   fill: rgba(240, 240, 245, 0.6);
   z-index: 1;
   transition: all 0.2s ease-out;
}

.about-img svg:hover {
   fill: rgba(18, 190, 131, 0.6);
   width: 65px;
   height: 65px;
}

.about-img:hover::before {
   background: rgba(0, 0, 0, 0.3);
}

.about-img:hover::after {
   opacity: 1;
   visibility: visible;
   transform: scale(1);
}


/* video */
.about-video {
   width: 100%;
   height: 100%;
   border-radius: 10px;
   overflow: hidden;
}

.about-video iframe {
   width: 100%;
}


@media all and (max-width: 990px) {
   .about-img::after { transform: scale(1.02); }
}
</style>