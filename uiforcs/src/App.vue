<script setup>
import Reviewer from "@/components/Reviewer.vue";
</script>

<template>
    <div id="app-root">
    <Reviewer />
    </div>
</template>

<style>
#app-root {
  width: 600px;
  height: 800px;
  margin: 0 auto;
  display: flex;
  align-items: center;
  justify-content: center;
  /* 可选：让页面背景和内容区分开 */
  background: #f0f0f0;
}
body, html {
  width: 100%;
  height: 100%;
  margin: 0;
  padding: 0;
  overflow: auto;
}
</style>

