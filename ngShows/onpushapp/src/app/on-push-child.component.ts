import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { User } from './user.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-on-push-child',
  standalone: true,
  imports: [DatePipe],
  template: `
    <div class="child">
      <h3>Child Component (OnPush)</h3>
      <p>User: {{ user.name }}, Age: {{ user.age }}</p>
      <p>Last Checked: {{ lastChecked | date: 'HH:mm:ss' }}</p>
    </div>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class OnPushChildComponent {
  @Input() user!: User;
  lastChecked = new Date();

  ngDoCheck() {
    this.lastChecked = new Date();
    console.log('Child: ngDoCheck ran (OnPush)');
  }
}
