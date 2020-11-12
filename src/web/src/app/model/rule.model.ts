import { EnumModel } from './enum.model';

export interface RuleModel {
  id: string,
  days: number,
  type: number,
  typeModel: EnumModel,
  interestPerDay: number,
  penalty: number,
  active: boolean
}
