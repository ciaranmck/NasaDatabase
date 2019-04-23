import * as THREE from 'three';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EngineService {
  private canvas: HTMLCanvasElement;
  private renderer: THREE.WebGLRenderer;
  private camera: THREE.PerspectiveCamera;
  private scene: THREE.Scene;
  private light: THREE.AmbientLight;

  private sphere: THREE.Mesh;

  createScene(elementId: string): void {
    this.canvas = <HTMLCanvasElement>document.getElementById(elementId);

    this.renderer = new THREE.WebGLRenderer({
      canvas: this.canvas,
      alpha: true,    // transparent background
      antialias: true // smooth edges
    });
    this.renderer.setSize(window.innerWidth, window.innerHeight);

    // create the scene
    this.scene = new THREE.Scene();

    this.camera = new THREE.PerspectiveCamera(
      75, window.innerWidth / window.innerHeight, 0.1, 1000
    );
    this.camera.position.z = 4;
    this.scene.add(this.camera);

    // soft white light
    this.light = new THREE.AmbientLight( 'white', 1 );
    this.light.position.z = 10;
    this.scene.add(this.light);

    const spGeo = new THREE.SphereGeometry(2, 50, 50);
    const planetTexture = new THREE.TextureLoader().load('assets/earthTexture.png');
    const material =  new THREE.MeshPhongMaterial({
        map: planetTexture,
        shininess: 0.2
      });
    this.sphere = new THREE.Mesh(spGeo, material);
    this.scene.add(this.sphere);
  }

  animate(): void {
    window.addEventListener('DOMContentLoaded', () => {
      this.render();
    });

    window.addEventListener('resize', () => {
      this.resize();
    });
  }

  render() {
    requestAnimationFrame(() => {
      this.render();
    });

    this.sphere.rotation.y -= 0.001;
    this.renderer.render(this.scene, this.camera);
  }

  resize() {
    const width = window.innerWidth;
    const height = window.innerHeight;

    this.camera.aspect = width / height;
    this.camera.updateProjectionMatrix();

    this.renderer.setSize( width, height );
  }
}
