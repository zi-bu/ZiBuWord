import { fileURLToPath, URL } from 'node:url'
import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueDevTools from 'vite-plugin-vue-devtools'

export default defineConfig({
  plugins: [
    vue(),
    vueDevTools({
      editor: {
        apiVersion: 2,
        command: 'C:\\Users\\Gushiina\\AppData\\Local\\Programs\\Rider\\bin\\rider64.exe',
        args: ['{{file}}:{{line}}:{{column}}'],
        enabled: true,
        defaultEditor: 'rider',
        editorMode: 'local'
      }
    })
  ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  }
})