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
  <p class="watermark">图片源于画师@mutugi,仅用于展示</p>
  <div id="app-root">
    <transition name="fade-page" mode="out-in">
      <component :is="currentPageComponent" @panelClick="switchPage" :key="currentPage" />
    </transition>
  </div>
</template>


<style>
.fade-page-enter-active,
.fade-page-leave-active {
  transition: opacity 0.5s;
}

.fade-page-enter-from,
.fade-page-leave-to {
  opacity: 0;
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