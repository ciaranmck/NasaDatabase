import * as THREE from 'three';
import { Injectable } from '@angular/core';
import Fireball from '../shared/models/Fireball';

@Injectable({
  providedIn: 'root'
})
export class EngineService {
  private canvas: HTMLCanvasElement;
  private renderer: THREE.WebGLRenderer;
  private camera: THREE.PerspectiveCamera;
  private scene: THREE.Scene;
  private light: THREE.AmbientLight;

  private earth: THREE.Mesh;
  private impactPoints: THREE.Mesh;
  private xyzPositions;

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
    this.camera.position.z = 250;
    this.scene.add(this.camera);

    // soft white light
    this.light = new THREE.AmbientLight('white', 1);
    this.light.position.z = 10;
    this.scene.add(this.light);

    const innerSphere = new THREE.SphereGeometry(100, 50, 50);
    const earthTexture = new THREE.TextureLoader().load('assets/earthTexture.png');
    const material = new THREE.MeshPhongMaterial({
      map: earthTexture,
      shininess: 0.2
    });
    this.earth = new THREE.Mesh(innerSphere, material);
    this.scene.add(this.earth);
  }

  public getXYZCoordinates(fireballData: Fireball[]) {
    const xyzPositions = [];

    fireballData.forEach(fireball => {
      const vector = this.calcPosFromLatLonRad(110, fireball.lat, fireball.lon);
      xyzPositions.push(vector);

      if (xyzPositions.length < 50) {
        this.createSphere(vector);
      }
    });
    this.xyzPositions = xyzPositions;
  }

  calcPosFromLatLonRad(radius, lat, lon) {
    const spherical = new THREE.Spherical(
      radius,
      THREE.Math.degToRad(90 - lon),
      THREE.Math.degToRad(lat)
    );

    const vector = new THREE.Vector3();
    vector.setFromSpherical(spherical);

    return vector;
  }

  private createSphere(point: THREE.Vector3): void {
    const outerSphere = new THREE.SphereGeometry(2, 50, 50);
    const planetTexture2 = new THREE.TextureLoader().load('assets/earthTexture.png');
    const material2 =  new THREE.MeshPhongMaterial({
      // map: planetTexture2,
      shininess: 0.2
    });
    const fireBall = new THREE.Mesh(outerSphere, material2);
    this.scene.add(fireBall);
    fireBall.translateX(point.x);
    fireBall.translateY(point.y);
    fireBall.translateZ(point.z);
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

    this.earth.rotation.y += -0.001;
    this.renderer.render(this.scene, this.camera);
  }

  resize() {
    const width = window.innerWidth;
    const height = window.innerHeight;

    this.camera.aspect = width / height;
    this.camera.updateProjectionMatrix();

    this.renderer.setSize(width, height);
  }
}
