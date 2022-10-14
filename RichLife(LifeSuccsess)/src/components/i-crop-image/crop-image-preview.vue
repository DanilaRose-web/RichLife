<template>
  <div class="cr-preview" :style="blockStyle" ref="preview" :class="{ round: round }">
    <img :src="imageSrc" class="cr-image" :style="crImage" />
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop, Watch } from 'vue-property-decorator';
import { URL } from 'url';
import ImagePreviewModel from './ImagePreviewModel';
@Component({
  name: 'crop-image-preview',
})
export default class CropImagePreviewComponent extends Vue {
  // @Prop() type: string;
  @Prop({ type: Object }) cropParams: ImagePreviewModel;
  //Отношение ширины к высоте
  @Prop({ default: 1 }) aspectRatio: number;
  @Prop({ default: '/assets/img/no_image.svg' }) defaultImage: string;
  @Prop({ default: 80 }) elHeight: number;
  @Prop({ default: false }) round: Boolean;

  @Watch('cropParams', { deep: true })
  onUpdateParamsCrop() {
    this.recalcStyle();
    //  console.log('crop params changed: ', this.cropParams);
  }

  // @Prop() imageSrc: string;
  // @Watch("imageSrc")
  // onUpdateParamsSrc() {
  //   this.recalcStyle();
  // }
  get imageSrc(): string {
    return (this.cropParams || {}).ImageUrl || this.defaultImage;
  }

  mounted() {
    // this.$emit("input", this.elHeight);
    this.recalcClientHeight();
    this.recalcStyle();
    window.addEventListener('resize', this.recalcClientHeight);
  }
  get blockStyle(): Object {
    return {
      height: `${this.elHeight}px`,
      width: `${this.elHeight * this.aspectRatio}px`,
    };
  }

  //#region computed
  defaultStyle = {
    height: `${this.elHeight}px`,
    width: '100%',
    // transform: "translateY(-50%)",
    // top: "50%",
  };

  crImage = {};
  isCropped(): boolean {
    return !!this.cropParams && !!this.cropParams.ImageUrl && !!this.cropParams.Height && !!this.cropParams.Width && this.cropParams.Left != null && this.cropParams.Top != null;
  }
  recalcStyle() {
    let aspect = this.elHeight / this.cropParams.Height;
    aspect = Number.isNaN(aspect) ? 1 : aspect;
    if (this.isCropped()) {
      let i = new Image();
      i.onload = () => {
        this.crImage = {
          left: -(this.cropParams.Left || 0) * aspect + 'px',
          top: -(this.cropParams.Top || 0) * aspect + 'px',
          height: (i.height || 1) * aspect + 'px',
        };
      };
      i.src = this.cropParams.ImageUrl;
    } else {
      this.crImage = this.defaultStyle;
    }
  }

  //#endregion
  //#region methods: {
  recalcClientHeight() {
    if (this.$refs.preview) this.height = (this.$refs.preview as any).clientHeight;
  }
  //#endregion
}
</script>

<style lang="less" scoped>
@cropImagePreviewBorderColor: #394e72;
.cr-preview {
  position: relative;
  overflow: hidden;
  text-align: left;
  border-radius: 50%;
  &.round {
    border-radius: 50%;
  }
  .cr-image {
    position: absolute;
    z-index: 1;
    background-color: #293b5a;
  }
}
.max {
  height: 80px;
  width: 304px;
}
.min {
  height: 80px;
  width: 80px;
}
.fluid {
  height: 100%;
  width: 100%;
  position: absolute;
}
</style>
