from matplotlib import pyplot as plt
import pandas as pd

def count_unique_players(csv_file):
    data = pd.read_csv(csv_file)
    unique_players = data['participantId'].nunique()
    return unique_players

def participant_statistics(csv_file):
    data = pd.read_csv(csv_file)
    mean_participant = data['participantId'].mean()
    median_participant = data['participantId'].median()
    mode_participant = data['participantId'].mode()[0]
    return mean_participant, median_participant, mode_participant

def count_unique_events(csv_file):
    data = pd.read_csv(csv_file)
    unique_events = data['eventName'].nunique()
    return unique_events

def event_statistics(csv_file):
    data = pd.read_csv(csv_file)
    mean_event = data['eventName'].value_counts().mean()
    median_event = data['eventName'].value_counts().median()
    mode_event = data['eventName'].value_counts().mode()[0]
    return mean_event, median_event, mode_event

def timestamp_statistics(csv_file):
    data = pd.read_csv(csv_file)
    data['timestamp'] = pd.to_datetime(data['timestamp'])
    mean_time = data['timestamp'].mean()
    median_time = data['timestamp'].median()
    mode_time = data['timestamp'].mode()[0]
    return mean_time, median_time, mode_time

def scene_name_count(csv_file):
    data = pd.read_csv(csv_file)
    scene_counts = data['sceneName'].value_counts()
    return scene_counts

def turns_completed_statistics(csv_file):
    data = pd.read_csv(csv_file)
    mean_turns = data['turnsCompleted'].mean()
    median_turns = data['turnsCompleted'].median()
    mode_turns = data['turnsCompleted'].mode()[0]
    std_turns = data['turnsCompleted'].std()
    
    return mean_turns, median_turns, mode_turns, std_turns

def turns_completed_statistics(csv_file):
    data = pd.read_csv(csv_file)
    mean_turns = data['turnsCompleted'].mean()
    median_turns = data['turnsCompleted'].median()
    mode_turns = data['turnsCompleted'].mode()[0]
    min_turns = data['turnsCompleted'].min()
    max_turns = data['turnsCompleted'].max()
    return mean_turns, median_turns, mode_turns, min_turns, max_turns

def time_taken_statistics(csv_file):
    data = pd.read_csv(csv_file)
    mean_time_taken = data['timeTakenToComplete'].mean()
    median_time_taken = data['timeTakenToComplete'].median()
    mode_time_taken = data['timeTakenToComplete'].mode()[0]
    min_time_taken = data['timeTakenToComplete'].min()
    max_time_taken = data['timeTakenToComplete'].max()
    return mean_time_taken, median_time_taken, mode_time_taken, min_time_taken, max_time_taken

def total_turns_completed_statistics(csv_file):
    data = pd.read_csv(csv_file)
    mean_total_turns = data['totalTurnsCompleted'].mean()
    median_total_turns = data['totalTurnsCompleted'].median()
    mode_total_turns = data['totalTurnsCompleted'].mode()[0]
    min_total_turns = data['totalTurnsCompleted'].min()
    max_total_turns = data['totalTurnsCompleted'].max()
    return mean_total_turns, median_total_turns, mode_total_turns, min_total_turns, max_total_turns

def games_completed_statistics(csv_file):
    data = pd.read_csv(csv_file)
    mean_games_completed = data['gamesCompleted'].mean()
    median_games_completed = data['gamesCompleted'].median()
    mode_games_completed = data['gamesCompleted'].mode()[0]
    min_games_completed = data['gamesCompleted'].min()
    max_games_completed = data['gamesCompleted'].max()
    return mean_games_completed, median_games_completed, mode_games_completed, min_games_completed, max_games_completed

def time_taken_in_game_statistics(csv_file):
    data = pd.read_csv(csv_file)
    mean_time_taken_in_game = data['timeTakenInGame'].mean()
    median_time_taken_in_game = data['timeTakenInGame'].median()
    mode_time_taken_in_game = data['timeTakenInGame'].mode()[0]
    min_time_taken_in_game = data['timeTakenInGame'].min()
    max_time_taken_in_game = data['timeTakenInGame'].max()    
    return mean_time_taken_in_game, median_time_taken_in_game, mode_time_taken_in_game, min_time_taken_in_game, max_time_taken_in_game

def time_spent_in_game_statistics(csv_file):
    data = pd.read_csv(csv_file)
    mean_time_spent_in_game = data['timeSpentInGame'].mean()
    median_time_spent_in_game = data['timeSpentInGame'].median()
    mode_time_spent_in_game = data['timeSpentInGame'].mode()[0]
    min_time_spent_in_game = data['timeSpentInGame'].min()
    max_time_spent_in_game = data['timeSpentInGame'].max()
    return mean_time_spent_in_game, median_time_spent_in_game, mode_time_spent_in_game, min_time_spent_in_game, max_time_spent_in_game

