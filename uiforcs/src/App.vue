<script setup lang="ts">
import Reviewer from "@/components/Reviewer.vue";
import Riciter from "./components/Riciter.vue";
import Mainpage from "./components/Mainpage.vue";
import { ref, computed } from "vue";

const currentPage = ref("Mainpage");
function switchPage(page: string) {
  currentPage.value = page;
}
const currentPageComponent = computed(() => {
  if (currentPage.value === "Mainpage") return Mainpage;
  if (currentPage.value === "ReviewTime") return Reviewer;
  if (currentPage.value === "StartToLearn") return Riciter;
  return Mainpage;
});
</script>

<template>
  <p class="watermark">图片源于画师pinterest,仅用于展示,非商业用途</p>
  <div id="app-root">
    <transition name="scale-page" mode="out-in">
      <component :is="currentPageComponent" @panelClick="switchPage" :key="currentPage" />
    </transition>
  </div>
</template>


<style>
.scale-page-enter-active,
.scale-page-leave-active {
  transition:
    opacity 0.35s cubic-bezier(.4, 2.3, .3, 1),
    transform 0.35s cubic-bezier(.4, 2.3, .3, 1);
  will-change: opacity, transform;
}



.scale-page-enter-from {
  opacity: 0;
  transform: scale(0.85)
    /* 新页面从小到大 */
  ;
}

.scale-page-enter-to {
  opacity: 1;
  transform: scale(1);
}

.scale-page-leave-from {
  opacity: 1;
  transform: scale(1);
}

.scale-page-leave-to {
  opacity: 0;
  transform: scale(0.32)
    /* 旧页面缩小消失 */
  ;
}

.watermark {
  position: fixed;
  top: 8px;
  left: 12px;
  color: #000;
  opacity: 0.18;
  font-size: 14px;
  pointer-events: none;
  z-index: 9999;
  user-select: none;
  border-radius: 30px;
}

#app-root {
  width: 600px;
  height: 800px;
  margin: 0;
  position: absolute;
  top: 0;
  left: 0;
  border-radius: 32px;
  /* 圆角 */
  overflow: hidden;
  /* 防止内容溢出圆角外 */
}
</style>