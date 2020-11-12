import { Interface } from "readline";
import { RuleModel } from './rule.model';

export interface accountModel {
  id: string,
  name: string,
  originalValue: number,
  paymentDate: Date,
  dueDate: Date,
  correctedValue: number,
  numberOfDaysLate: number,
  rule: RuleModel
}
