import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState, AppThunk } from '../../app/store';

export interface 
public record class LearningTask(string Id, string? ProjectColumns, string? Description);
public record class LearningModule(string Id, string? Name, ICollection<LearningTask> Tasks);
public record class LearningTaskSolution(string Id, string Query, int RowCount);

export interface TasksTreeSlice {


}