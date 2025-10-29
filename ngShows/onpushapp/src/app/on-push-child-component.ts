import { Component, Input, ChangeDetectionStrategy } from '@angular/core';
import { User } from './user.model';

@Component({
  selector: 'app-on-push-child',
  template: `
    <div style="border: 2px solid green; padding: 10px; margin-top: 10px;">
      <h4>🟢 OnPush Child Component</h4>
      <p>Name: <strong>{{ user.name }}</strong></p>
      <p>Age: <strong>{{ user.age }}</strong></p>
      <p>Last Checked: {{ lastChecked | date: 'HH:mm:ss' }}</p>
    </div>
  `,
  // This is the key: only check for changes if inputs change reference or an event fires.
  changeDetection: ChangeDetectionStrategy.OnPush 
})
export class OnPushChildComponent {
  @Input() user!: User;
  lastChecked = new Date();

  // Lifecycle hook called when Angular checks this component for changes
  ngDoCheck() {
    this.lastChecked = new Date();
    console.log('Child: ngDoCheck ran (OnPush)');
  }
}